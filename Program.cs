
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.AspNetCore;
using QuartzExample.API.Data;
using QuartzExample.API.Job;
using QuartzExample.API.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddDbContext<AppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer"))

);

builder.Services.AddQuartz(options =>
{
    var jobKey = new JobKey("StatusCheck");
    options.AddJob<OrderStatusCheckJob>(o => o.WithIdentity(jobKey));

    options.AddTrigger(opts => opts
        .ForJob(jobKey)       
        .WithCronSchedule("0 0/1 * * * ?"));
});
builder.Services.AddQuartzServer(options =>
{
    // when shutting down we want jobs to complete gracefully
    options.WaitForJobsToComplete = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
