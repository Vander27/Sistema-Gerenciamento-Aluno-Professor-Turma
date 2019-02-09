var app = angular.module(
    'app-aula', //nome do aplicativo
    ['ngRoute'] //suporte a mapeamento de rotas
);

app.config(
    function ($routeProvider) {

        $routeProvider
            .when(
            '/aluno/cadastro', //URL (rota)..    
            {
                templateUrl: "/App/Views/Aluno/cadastro.html",
                controller: "AlunoCadastroController"
            }
            )
            .when(
            '/aluno/consulta', //URL (rota)..           
            {
                templateUrl: "/App/Views/Aluno/consulta.html"
            }
            )
            .when(
            '/professor/cadastro', //URL (rota)..           
            {
                templateUrl: "/App/Views/Professor/cadastro.html"
            }
            )
            .when(
            '/professor/consulta', //URL (rota)..          
            {
                templateUrl: "/App/Views/Professor/consulta.html"
            }
            )
            .when(
            '/turma/cadastro', //URL (rota)..       
            {
                templateUrl: "/App/Views/Turma/cadastro.html"
            }
            )
            .when(
            '/turma/consulta', //URL (rota)..          
            {
                templateUrl: "/App/Views/Turma/consulta.html"
            }
            );
    }
);

//função para fazer funcionar as rotas..
app.config(function ($locationProvider) {
    $locationProvider.hashPrefix('');
});
