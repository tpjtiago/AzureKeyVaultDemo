using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace KeyVaultDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Substitua com os valores do seu aplicativo registrado e Key Vault
            var tenantId = "";
            var clientId = "";
            var clientSecret = "";
            var keyVaultUrl = new Uri("https://vault.azure.net/");

            // Nome do segredo que você quer acessar
            string secretName = "ConnectionString";

            // Autenticação usando ClientSecretCredential
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

            // Cliente do Key Vault
            var client = new SecretClient(vaultUri: keyVaultUrl, credential: credential);

            try
            {
                // Obter o segredo
                KeyVaultSecret secret = client.GetSecret(secretName);

                // Exibir o valor do segredo
                Console.WriteLine($"Secret: {secretName}, Value: {secret.Value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar o Key Vault: {ex.Message}");
            }
        }
    }
}
