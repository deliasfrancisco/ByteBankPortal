using ByteBankPortal.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankPortal
{
	class Program
	{
		static void Main(string[] args)
		{
			var prefixos = new string[] { "http://localhost:4615/" };
			var webApplication = new WebApplication(prefixos);
			webApplication.Iniciar();
		}
	}
}
