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

            let cpfTd = document.createElement('td');
            cpfTd.classList.add('row-cpf-cliente');
            
            let dataNascimentoTd = document.createElement('td');
            dataNascimentoTd.classList.add('row-dataNascimento-cliente');

            let telefoneTd = document.createElement('td');
            telefoneTd.classList.add('row-telefone-cliente');

            let emailTd = document.createElement('td');
            emailTd.classList.add('row-email-cliente');

            let dataCadastroTd = document.createElement('td');
            dataCadastroTd.classList.add('row-dataCadastro-cliente');
                        
            idUsuarioInput.innerHTML = e.idUsuario;
            nomeTd.innerHTML = e.nome;
            cpfTd.innerHTML = e.cpf;
            dataNascimentoTd.innerHTML = e.dataNascimento;
            telefoneTd.innerHTML = e.telefone;
            emailTd.innerHTML = e.email;
            dataCadastroTd.innerHTML = e.dataCadastro;            
            
    
            linha.appendChild(idUsuarioInput);
            linha.appendChild(nomeTd);
            linha.appendChild(cpfTd); 
            linha.appendChild(dataNascimentoTd); 
            linha.appendChild(telefoneTd); 
            linha.appendChild(emailTd); 
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