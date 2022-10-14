async function PreencherTabelaClientes(resposta, limpar){
    
    let tabela = document.querySelector('#listagem-cliente');    

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
            
            
            let idUsuarioInput = document.createElement('td');
            idUsuarioInput.classList.add('row-idUsuario-cliente');

            let nomeTd = document.createElement('td');
            nomeTd.classList.add('row-nome-cliente');

            let dataCadastroTd = document.createElement('td');
            dataCadastroTd.classList.add('row-dataCadastro-cliente');
                        
            idUsuarioInput.innerHTML = e.idUsuario;
            nomeTd.innerHTML = e.nome;
            dataCadastroTd.innerHTML = e.dataCadastro;            
            
    
            linha.appendChild(idUsuarioInput);
            linha.appendChild(nomeTd);
            linha.appendChild(dataCadastroTd);                       
            
            tabela.appendChild(linha);

            return linha;         

    
        });
    }
}
async function ListarClientes(){  
    
    const options = {
        method: 'GET',  
        headers:{'content-type': 'application/json'}                     
    };    
    const req =  fetch('https://localhost:44335/cliente/ReadAll', options )
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
    const req =  await fetch('https://localhost:44335/cliente/GetUsuario?login='+criterio, options )
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
    let res = await ListarClientes();
    PreencherTabelaClientes(res, false);    
})();