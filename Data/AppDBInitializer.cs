using cadastro_clientes.Models;

namespace cadastro_clientes.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCont>();
                context.Database.EnsureCreated();

                //Criar Tarefas
                if (!context.Clientes.Any())
                {
                    context.Clientes.AddRange(new List<Cliente>()

                    {
                        new Cliente()
                        {
                            Name = "Carlos Silva dos Santos",
                            Telefone = "21 99234-9958",
                            Email = "carlos12@gmail.com",
                            Pais = "Brasil",
                            UF = "RJ",
                            Cidade = "Rio de Janeiro",
                            Bairro = "Sepetiba",
                            Rua = "Rua 1 (Cj Tijolinho)",
                            Numero = "9",
                            Complemento = "",
                            Cep = "23548-007"
                        },
                        new Cliente()
                        {
                            Name = "Marcos Pereira da Silva",
                            Telefone = "21 98234-9958",
                            Email = "marcos@gmail.com",
                            Pais = "Brasil",
                            UF = "RJ",
                            Cidade = "Rio de Janeiro",
                            Bairro = "Santa Cruz",
                            Rua = "Rua 1 (Cj Cesarão)",
                            Numero = "5",
                            Complemento = "",
                            Cep = "23595-180"
                        },
                        new Cliente()
                        {
                            Name = "Anderson Silva da Cunha Euclides",
                            Telefone = "81 97958-9958",
                            Email = "anderson@gmail.com",
                            Pais = "Brasil",
                            UF = "PE",
                            Cidade = "Abreu e Lima",
                            Bairro = "Desterro",
                            Rua = "Rua Alameda Jaborandi de Pernambuco",
                            Numero = "25",
                            Complemento = "",
                            Cep = "53575-126"
                        },
                        new Cliente()
                        {
                            Name = "José Antônio Carlos de Oliveira",
                            Telefone = "13 99234-9958",
                            Email = "jose@gmail.com",
                            Pais = "Brasil",
                            UF = "SP",
                            Cidade = "Bertioga",
                            Bairro = "Albatróz",
                            Rua = "Avenida 19 de Maio",
                            Numero = "7",
                            Complemento = "apt3",
                            Cep = "11250-787"
                        },
                        new Cliente()
                        {
                            Name = "Maria Antônia da Cunha",
                            Telefone = "21 99234-9958",
                            Email = "maria@gmail.com",
                            Pais = "Brasil",
                            UF = "RJ",
                            Cidade = "Rio de Janeiro",
                            Bairro = "Copacabana",
                            Rua = "Avenida Atlântica",
                            Numero = "3848",
                            Complemento = "apt15",
                            Cep = "22070-002"
                        }
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
