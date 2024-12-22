using Database.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.DesignTimeOption
{
	internal class ContextFactory : IDesignTimeDbContextFactory<MyDbContext>
	{
		public MyDbContext CreateDbContext(string[] args)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddUserSecrets(Assembly.GetExecutingAssembly());
			var configuration = builder.Build();
			var url = configuration.GetSection("ConnectionString").Value;
            return new MyDbContext(url);
		}
	}
}
