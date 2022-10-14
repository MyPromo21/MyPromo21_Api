function Salvar(){
    var login = document.querySelector("#login").value;
    var password = document.querySelector("#password").value;
    var nivel = document.querySelector("#nivel").value;
    var nome = document.querySelector("#nome").value;
    var dataNascimento = document.querySelector("#dataNascimento").value;
    var unidade = document.querySelector("#unidade").value;

    var tabela = document.querySelector("#tabelaDados");

    var linha = document.createElement('tr');

    var tdlogin = document.createElement('td');
    tdlogin.innerHTML = login;
    linha.appendChild(tdlogin);

    var tdpassword = document.createElement('td');
    tdpassword.innerHTML = password;
    linha.appendChild(tdpassword);

    var tdnivel = document.createElement('td');
    tdnivel.innerHTML = nivel;
    linha.appendChild(tdnivel);

    var tdnome = document.createElement('td');
    tdnome.innerHTML = nome;
    linha.appendChild(tdnome);

    var tddataNascimento = document.createElement('td');
    tddataNascimento.innerHTML = dataNascimento;
    linha.appendChild(tddataNascimento);

    var tdunidade = document.createElement('td');
    tdunidade.innerHTML = unidade;
    linha.appendChild(tdunidade);


    tabela.appendChild(linha);
}