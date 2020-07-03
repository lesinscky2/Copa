var equipe = function () {

    var equipes = [];

    var alterarContagemEquipes = function () {

        $(".checkbox-equipe").on("change", function (e) {

            $("#contagem-equipes").html($(".checkbox-equipe:checked").length);
        });
    }

    var validarQuantidadeEquipes = function () {
        var quantidade = Number($(".checkbox-equipe:checked").length);

        if (quantidade !== 8) {
            $("#modalQuantidade").modal();
            return false;
        }

        return true;
    }

    var recuperarEquipesSelecionadas = function () {
        var equipesHtml = $(".checkbox-equipe:checked").closest(".equipe");

        for (var x = 0; x < equipesHtml.length; x++) {
            equipes.push(JSON.parse(equipesHtml[x].getAttribute("equipe")));
        }
    }

    var aplicarResultado = function (equipes) {
        $("#equipe-primeiro-lugar").html(equipes[0].nome);
        $("#equipe-segundo-lugar").html(equipes[1].nome);
    }

    var gerarCopa = function () {
        $("#gerar-copa").on("click", function (e) {
            e.preventDefault();

            if (validarQuantidadeEquipes() === true) {
                recuperarEquipesSelecionadas();

                $.ajax({
                    type: 'POST',
                    url: '/Equipe/GerarCopa',
                    dataType: 'json',
                    data: { equipes: JSON.stringify(equipes) },
                    success: function (equipes) {
                        aplicarResultado(equipes)
                        $("#selecao").hide();
                        $("#resultado").show();
                    }
                });
            }
            else {
                return false;
            }
        });
    }


    var ativarEventos = function () {
        alterarContagemEquipes();
        gerarCopa();

    }

    return {
        init: function () {
            ativarEventos();
        }
    }
}();