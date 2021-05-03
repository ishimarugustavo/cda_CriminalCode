# Configuração Inicial

1. - Ajustar a connection string com o banco de dados no arquivo `appsettings.json`
```
"ConnectionStrings": {
    "CriminalCodeDatabase": "Server=\\SQLEXPRESS;Database=CriminalCode.API.Db;Trusted_Connection=True;"
}
```

2. - Executar o migrations para criar as tabelas no banco de dados
```
dotnet ef migrations add CriminalCode.DB
dotnet ef database update
```

3. - Agora podemos executar a aplicação e acessar o swagger através do link `https://localhost:5001/swagger/index.html`
