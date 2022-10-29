using AspNetCoreRateLimit;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions(); // reading appsettings.json
// reading cache service (takes request number to memory)
builder.Services.AddMemoryCache();
//builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting"));
//builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.Configure<ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies"));

// adds reference
// builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();
// builder.Services.AddSingleton<IIpPolicyStore, DistributedCacheIpPolicyStore>(); => for multiple applications
// adds reference (one reference in all application)
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

// to read request data (header, ip vs.)
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

// main interface
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// for IpPolicies
//var IpPolicy = app.Services.GetRequiredService<IIpPolicyStore>();
var ClientPolicy = app.Services.GetRequiredService<IClientPolicyStore>();

// wait until get response
//IpPolicy.SeedAsync().Wait();
ClientPolicy.SeedAsync().Wait();

// uses upper features and puts ip rate limit
//app.UseIpRateLimiting();
app.UseClientRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
