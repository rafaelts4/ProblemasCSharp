using INSS;
using NUnit.Framework;
using System;
using System.IO;

namespace TestProjectINSS
{
    public class CalculadorInssTests
    {        
        ICalculadorInss calculadorInss = new CalculadorInss();

        [SetUp]
        public void Setup()
        {
            const string DB_FILE = "DbINSS.mdf";
            if (File.Exists(DB_FILE))
                throw new FileNotFoundException($"Arquivo {DB_FILE} não encontrado.");
        }

        [Test]
        public void CalculaDescontoDeValorInferiorAoPrimeiroRange()
        {

            decimal salario = 1000M;
            decimal taxa = 0.08M;
            decimal descontoObtido = calculadorInss.CalcularDesconto(new DateTime(2011, 1, 1), salario);
            decimal resultadoEspeado = salario * taxa;
            Assert.AreEqual(descontoObtido, resultadoEspeado);

            salario = 999.9M;
            taxa = 0.07M;
            descontoObtido = calculadorInss.CalcularDesconto(new DateTime(2012, 1, 1), salario);
            resultadoEspeado = salario * taxa;            
            Assert.AreEqual(descontoObtido, resultadoEspeado);
        }

        [Test]
        public void CalculaDescontoDeValorDentroDeUmRange()
        {

            decimal salario = 1106.91M;
            decimal taxa = 0.09M;
            decimal descontoObtido = calculadorInss.CalcularDesconto(new DateTime(2011, 1, 1), salario);
            decimal resultadoEspeado = salario * taxa;
            Assert.AreEqual(descontoObtido, resultadoEspeado);

            salario = 1500M;
            taxa = 0.08M;
            descontoObtido = calculadorInss.CalcularDesconto(new DateTime(2012, 1, 1), salario);
            resultadoEspeado = salario * taxa;
            Assert.AreEqual(descontoObtido, resultadoEspeado);
        }

        [Test]
        public void CalculaDescontoDeValorAcimaDoMaiorRange()
        {

            decimal salario = 3689.67M;            
            decimal descontoObtido = calculadorInss.CalcularDesconto(new DateTime(2011, 1, 1), salario);
            decimal resultadoEspeado = 405.86M;
            Assert.AreEqual(descontoObtido, resultadoEspeado);

            salario = 4001M;            
            descontoObtido = calculadorInss.CalcularDesconto(new DateTime(2012, 1, 1), salario);
            resultadoEspeado = 500;
            Assert.AreEqual(descontoObtido, resultadoEspeado);
        }
    }
}