import React from 'react';
import {useState, useEffect } from 'react'

function Index() {
    const [veiculos, setVeiculos] = useState([]);

    //to do criar função para buscar veiculos

    async function getVeiculos() {
        try {
            const respose = await fetch('https://localhost:7245/api/Veiculo/BuscarDisponivel')
            const data = await respose.json();
            console.log(data);
            setVeiculos(data);
        }
        catch (error) {
            console.erro("Erro ao obter veiculos", error);
        }
    }

    useEffect(() => {
        getVeiculos();
    }, []);

    return (
        <div className="veiculos-container">
            {
                veiculos.map(veiculo => (
                    <div key={veiculo.id} className="card">
                        <img src={veiculo.imagem} alt={`Veiculo ${veiculo.tipoVeiculo}`} />
                        <br/>
                        <div className="card-content">
                            <p>Tipo de Veiculo: {veiculo.tipoVeiculo}</p>
                            <p>Estado: {veiculo.estado}</p>
                            <p>Ano: {veiculo.anoFabricacao}</p>
                            <p>Placa: {veiculo.placa}</p>
                            <p>Preco: {veiculo.preco}</p>
                            <div class="cardveiculo" style="width: 18rem;">
                                <img src="public/Sedan.png" class="card-img-top" alt={`Veiculo ${veiculo.tipoVeiculo}`} />
                                <div class="card-body">
                                    <h5 class="VeiculoDisp">Card title</h5>
                                    <p class="card-text"></p>
                                    <a href="public/Sedan.png" class="Alugar Veiculo"></a>
                                    <a href="public/Sedan.png" class="Alugar Veiculo"></a>
                                </div>
                            </div>
                        </div>
                    </div>
                ))
            }
        </div>
    );
}

export default Index;