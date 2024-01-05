// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

        $(document).ready(function () {
            var $CPF = $("#CPF");
            var $Telefone = $("#Telefone");
            $CPF.mask('000.000.000-00', { reverse: true });
            $Telefone.mask('(00) 00000-0000', { reverse: false });
        });

        document.addEventListener("DOMContentLoaded", function () {
            const cepInput = document.getElementById('CEP');
            const cepStatus = document.getElementById('sCep');
            const ruaInput = document.getElementById('Rua');
            const numeroInput = document.getElementById('Numero');
            const bairroInput = document.getElementById('Bairro');
            const cidadeInput = document.getElementById('Cidade');
            const estadoInput = document.getElementById('Estado');

            cepInput.addEventListener('blur', function () {
                const cep = cepInput.value.replace(/\D/g, ''); // Remove caracteres não numéricos

                if (cep.length !== 8) {
                    alert('CEP inválido. Insira um CEP válido com 8 dígitos.');
                    cepInput.value = '';
                    ruaInput.value = '';
                    numeroInput.value = '';
                    bairroInput.value = '';
                    cidadeInput.value = '';
                    cepInput.focus;
                    return;
                }
                cepInput.disabled = true;
                ruaInput.disabled = true;
                numeroInput.disabled = true;
                bairroInput.disabled = true;
                cidadeInput.disabled = true;
                estadoInput.disabled = true;
                cepStatus.textContent = 'Buscando o endereço, aguarde...';

                fetch(`https://viacep.com.br/ws/${cep}/json/`)
                    .then(response => response.json())
                    .then(data => {
                        if (!data.erro) {
                            ruaInput.value = data.logradouro;
                            bairroInput.value = data.bairro;
                            cidadeInput.value = data.localidade;
                            estadoInput.value = data.uf;
                            cepInput.disabled = false;
                            ruaInput.disabled = false;
                            numeroInput.disabled = false;
                            bairroInput.disabled = false;
                            cidadeInput.disabled = false;
                            estadoInput.disabled = false;
                            cepStatus.textContent = '';
                            numeroInput.focus;
                            // Preencha outros campos de endereço, se necessário
                        }
                        else {
                            alert('CEP inválido!');
                            cepInput.value = '';
                            ruaInput.value = '';
                            numeroInput.value = '';
                            bairroInput.value = '';
                            cidadeInput.value = '';
                            cepStatus.textContent = '';
                            cepInput.disabled = false;
                            ruaInput.disabled = false;
                            numeroInput.disabled = false;
                            bairroInput.disabled = false;
                            cidadeInput.disabled = false;
                            estadoInput.disabled = false;
                            cepInput.focus;
                            return;
                        }
                    })
                    .catch(error => {
                        console.error('Erro ao buscar o CEP:', error);
                        cepInput.value = '';
                        ruaInput.value = '';
                        numeroInput.value = '';
                        bairroInput.value = '';
                        cidadeInput.value = '';
                        cepStatus.textContent = '';
                        cepInput.disabled = false;
                        ruaInput.disabled = false;
                        bairroInput.disabled = false;
                        cidadeInput.disabled = false;
                        estadoInput.disabled = false;
                        cepInput.focus;
                    });
            });
        });

        document.addEventListener("DOMContentLoaded", function () {
            const campoDataNascimento = document.getElementById('Nascimento');
            const elementoIdade = document.getElementById('Idade');

            campoDataNascimento.addEventListener('change', function () {
                const dataNascimento = new Date(campoDataNascimento.value);
                const hoje = new Date();
                const diff = hoje - dataNascimento;

                const idade = Math.floor(diff / (1000 * 60 * 60 * 24 * 365.25)); // Calcula a idade

                elementoIdade.value = idade;
            });
        });
