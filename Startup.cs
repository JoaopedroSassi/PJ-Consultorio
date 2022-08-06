using Consultorio.Context;
using Consultorio.Repository;
using Consultorio.Repository.Interfaces;
using Consultorio.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Consultorio
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().AddNewtonsoftJson(opt =>
			{
				opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			});
			services.AddDbContext<ConsultorioDbContext>(opt =>
			{
				opt.UseSqlServer(Configuration.GetConnectionString("Default"),
				assembly => assembly.MigrationsAssembly(typeof(ConsultorioDbContext).Assembly.FullName));
			});
			services.AddCors();


			//Dependency Inejections
			services.AddScoped<IBaseRepository, BaseRepository>();
			services.AddScoped<IPacienteRepository, PacienteRepository>();
			services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
			services.AddAutoMapper(typeof(Startup));
		}


		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
