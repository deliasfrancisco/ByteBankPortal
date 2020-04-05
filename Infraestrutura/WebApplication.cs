using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankPortal.Infraestrutura
{
	public class WebApplication
	{
		private readonly string[] _prefixos;

		public WebApplication(string[] prefixos)
		{
			if (prefixos == null)
				throw new ArgumentException(nameof(prefixos)); //1 nameof -> retorna uma string com o nome da variavel

			_prefixos = prefixos;
		}

		//http://bytebank.com
		public void Iniciar()
		{
			var httpListener = new HttpListener();

			foreach (var prefixo in _prefixos)
			{
				httpListener.Prefixes.Add(prefixo);
			}

			httpListener.Start();

			var contexto = httpListener.GetContext();//2 guardando o contexto até uma requisição chegar 
			var requisicao = contexto.Request;//3 requisição
			var resposta = contexto.Response; //4 resposta

			var respostaConteudo = "Hello Word"; //6 converter o texto em uma sequencia de bytes com o Stream
			var respostaConteudoBytes = Encoding.UTF8.GetBytes(respostaConteudo); //7 vai retornar a quantidade de bytes que o texto da variavel tem

			resposta.ContentType = "text/html; charset=utf-8"; //5 tipo de resposta que será trabalhado no contexto da requisição
			resposta.StatusCode = 200;   //Definir o codigo do status da conexão, o 200 significa que foi tudo certo e não houve nenhum problema com essa requisição
			resposta.ContentLength64 = respostaConteudoBytes.Length;  //indica para o navegador o tamanho da resposta que está na variavel respostaConteudoBytes

			resposta.OutputStream.Write(respostaConteudoBytes, 0, respostaConteudoBytes.Length); //escreve a resposta

			resposta.OutputStream.Close();
			httpListener.Stop(); 
		}
	}
}
