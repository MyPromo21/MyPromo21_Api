async function PreencherTabelaEstabelecimentos(resposta, limpar){
    
    let tabela = document.querySelector('#listagem-usuario');    

    if(limpar)
        tabela.innerHTML = '';

    if(!resposta)
        alert(resposta);
    else if(resposta.length == 0){
        tabela.innerHTML = 'Não há registros para exibir.';
    }
    else {
        resposta.forEach(function(e) {
            let linha = document.createElement('tr');
            
            linha.addEventListener('click', ()=> {            
                window.location.href = "./alterarUsuario.html?id=" + e.id;
            });
            
            
            let idEstabelecimentoInput = document.createElement('td');
            idEstabelecimentoInput.classList.add('row-idEstabelecimento-usuario');
            let nomeFantasiaTd = document.createElement('td');
            nomeFantasiaTd.classList.add('row-nomeFantasia-usuario');
            let cnpjTd = document.createElement('td');
            cnpjTd.classList.add('row-cnpj-usuario');
            
                        
            idEstabelecimentoInput.innerHTML = e.idEstabelecimento;
            nomeFantasiaTd.innerHTML = e.nomeFantasia;
            cnpjTd.innerHTML = e.cnpj;
            
    
            linha.appendChild(idEstabelecimentoInput);
            linha.appendChild(nomeFantasiaTd);
            linha.appendChild(cnpjTd);                       
            
            tabela.appendChild(linha);

            return linha;         

    
        });
    }
}
async function ListarEstabelecimentos(){  
    
    const options = {
        method: 'GET',  
        headers:{'content-type': 'application/json'}                     
    };    
    const req =  fetch('https://localhost:44335/estabelecimento/ReadAll', options )
        .then(response => {                
            return response.json();
        })     
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    return req;
}





function Voltar(){
    window.location.href = './index.html';   
}
async function ListarPorCriterio(elemento){
    let texto = elemento.value;
    let resposta = await ListarUsuariosUsandoCriterio(texto);
    PreencherTabelaUsuarios(resposta, true);
}
async function ListarUsuariosUsandoCriterio(criterio){  
    
    const options = {
        method: 'GET',  
        headers:{'content-type': 'application/json'}                     
    };    
    const req =  await fetch('https://localhost:44335/estabelecimento/GetUsuario?login='+criterio, options )
        .then(response => {              
            return response.json();
        })     
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    return req;
}
//inicia a listagem.
(async() => {
    let res = await ListarEstabelecimentos();
    PreencherTabelaEstabelecimentos(res, false);    
})();