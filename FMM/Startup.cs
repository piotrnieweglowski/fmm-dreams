using AutoMapper;
using FMM.Persistent;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using FMM.Common;
using Hellang.Middleware.ProblemDetails;

namespace FMM
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(Startup));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddProblemDetails(x =>
            {
                x.IncludeExceptionDetails = (ctx, ex) => false;
                x.Map<InvalidValidationException>(ex => new InvalidValidationProblemDetails(ex));
                x.Map<NotFoundException>(ex => new NotFoundProblemDetails(ex));
                x.Map<DbUpdateException>(ex => new DuplicateGuidDbProblemDetails(ex));
            });

            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DbConnection"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseProblemDetails();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
