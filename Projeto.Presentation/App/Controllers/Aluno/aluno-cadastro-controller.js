app.controller('AlunoCadastroController',
    function ($scope, $http) {

        //$scope -> comunicar com a página HTML
        //$http  -> comunicar com a API

        $scope.aluno = {
            Nome: "",
            Email: "",
            DataNascimento: ""
        }

        $scope.cadastrar = function () {

            $scope.mensagem = "Processando, por favor aguarde.";

            //executando o serviço..
            $http.post("http://localhost:57873/api/aluno/cadastrar", $scope.aluno)
                .then(function (result) {
                    $scope.mensagem = result.data;

                    //limpar os campos..
                    $scope.aluno.Nome = "";
                    $scope.aluno.Email = "";
                    $scope.aluno.DataNascimento = "";
                })
                .catch(function (e) {
                    $scope.mensagem = e.data;
                });
        }
    });