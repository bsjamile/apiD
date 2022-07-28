using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using WoMakersCode.ToDoList.Application.Mappings;
using WoMakersCode.ToDoList.Application.Models.Alarm.GetAlarm;
using WoMakersCode.ToDoList.Application.Models.Alarm.InsertAlarm;
using WoMakersCode.ToDoList.Application.Models.Alarm.UpdateAlarm;
using WoMakersCode.ToDoList.Application.Models.DeleteAlarm;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.DeleteTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.GetTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.InsertTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.UpdateTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskList.DeleteTaskList;
using WoMakersCode.ToDoList.Application.Models.TaskList.GetTaskList;
using WoMakersCode.ToDoList.Application.Models.TaskList.InsertTaskList;
using WoMakersCode.ToDoList.Application.Models.TaskList.UpdateTaskList;
using WoMakersCode.ToDoList.Application.UseCases;
using WoMakersCode.ToDoList.Application.UseCases.AlarmUseCase;
using WoMakersCode.ToDoList.Application.UseCases.TaskDetailUseCase;
using WoMakersCode.ToDoList.Application.UseCases.TaskListUseCase;
using WoMakersCode.ToDoList.Core.Filters;
using WoMakersCode.ToDoList.Core.Repositories;
using WoMakersCode.ToDoList.Infra.Database;
using WoMakersCode.ToDoList.Infra.Repositories;

namespace WoMakersCode.ToDoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITaskListRepository, TaskListRepository>();
            services.AddScoped<ITaskDetailRepository, TaskDetailRepository>();
            services.AddScoped<IAlarmRepository, AlarmRepository>();
            services.AddScoped<IUseCaseAsync<GetFilter, GetTaskListIdResponse>, GetTaskListIdUseCase>();
            services.AddScoped<IUseCaseAsync<GetAllTaskListRequest, List<GetAllTaskListResponse>>, GetAllTaskListUseCase>();
            services.AddScoped<IUseCaseAsync<InsertTaskListRequest, InsertTaskListResponse>, InsertTaskListUseCase>();   
            services.AddScoped<IUseCaseAsync<UpdateTaskListRequest, UpdateTaskListResponse>, UpdateTaskListUseCase>();   
            services.AddScoped<IUseCaseAsync<DeleteTaskListRequest, DeleteTaskListResponse>, DeleteTaskListUseCase>();
            services.AddScoped<IUseCaseAsync<GetAllTaskDetailRequest, List<GetAllTaskDetailResponse>>, GetAllTaskDetailUseCase>();
            services.AddScoped<IUseCaseAsync<InsertTaskDetailRequest, InsertTaskDetailResponse>, InsertTaskDetailUseCase>();
            services.AddScoped<IUseCaseAsync<UpdateTaskDetailRequest, UpdateTaskDetailResponse>, UpdateTaskDetailUseCase>();
            services.AddScoped<IUseCaseAsync<DeleteTaskDetailRequest, DeleteTaskDetailResponse>, DeleteTaskDetailUseCase>();
            services.AddScoped<IUseCaseAsync<GetAllAlarmRequest, List<GetAllAlarmResponse>>, GetAllAlarmUseCase>();
            services.AddScoped<IUseCaseAsync<InsertAlarmRequest, InsertAlarmResponse>, InsertAlarmUseCase>();
            services.AddScoped<IUseCaseAsync<List<InsertAlarmRequest>, List<InsertAlarmResponse>>, InsertMultAlarmUseCase>();
            services.AddScoped<IUseCaseAsync<UpdateAlarmRequest, UpdateAlarmResponse>, UpdateAlarmUseCase>();
            services.AddScoped<IUseCaseAsync<DeleteAlarmRequest, DeleteAlarmResponse>, DeleteAlarmUseCase>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
             );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WoMakersCode.ToDoList", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WoMakersCode.ToDoList v1"));
            }

            context.Database.Migrate();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
