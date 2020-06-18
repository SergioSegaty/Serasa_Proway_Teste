Teste Serasa e ProWay
=====================

Instalação
----------

[Requisitos] Para fazer o Setup do Backend -- \>

    Visual Studio 2019

    Entrar na pasta Serasa_Proway_Teste e abrir o arquivo .SLN

    Certificar-se que o App Url dentro das Configurações do App  é 'http://localhost:59044'

    - Iniciar o ISS - > Esperar aproximadamente 20 segundos para serem feitos os Builders.

[Requisitos] Para fazer o Setup do FrontEnd -- \>

    npm, yarn ou outro.



     - entrar na pasta react-app, abrir o CMD e escrever 'npm install' e 
    depois escrever 'npm start' para inicar como Desenvolvimento.

Usando o Site
-------------

Para usar o Teste basta escolher a Empresa e adicionar o Arquivo Seed.

O arquivo está estruturado como um Json, ele vai ser deserializado no Backend.

    {
        "NumeroNotasFiscais": 3,
        "NumeroDebitos": 1
    }

APIs
----

        DebitoController
            - // Post - api/Debitos (Usei apenas para fazer os meus testes iniciais)

            - // Get - api/Debitos ( Usei apenas para fazer os meus testes iniciais )

        NotasFiscaisController
            - // Post - api/NotasFiscais (Usei apenas para fazer os meus testes iniciais)

            - // Get - api/NotasFiscais ( Usei apenas para fazer os meus testes iniciais )

        EmpresasController
            - // Get/Id - api/Empresas/{id}
                -> Pegar a Empresa por Id

            - // Post - api/Empresas/EnviarArquivo/{id}
                -> Postar o Arquivo Seed por Id da Empresa

            - // GetTexto - api/Empresas/EscreverTodos
                -> Fazer o download do sumário das empresas em texto

            - // GetAll - api/Empresas
                -> Pegar todas as empresas para popular a Tabela e o Select.

