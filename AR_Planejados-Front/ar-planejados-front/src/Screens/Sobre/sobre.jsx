
import { Link } from "react-router-dom";
import Header from "../../Components/Header/header";
import "./Sobre.css";

const WHATSAPP_URL = "https://wa.me/5511947748822";

function Sobre() {
  return (
    <div className="pagina-sobre">
      <Header />

      <main>
        {/* BANNER */}
        <section className="banner-sobre">
          <div className="conteudo-banner-sobre">
            <span className="subtitulo-sobre">
              CONHEÇA A AR PLANEJADOS
            </span>

            <h1>
              Transformamos ideias em
              <span> ambientes únicos.</span>
            </h1>

            <p>
              Criamos soluções em móveis planejados que unem
              sofisticação, funcionalidade e personalidade.
            </p>

            <a href="#nossa-historia" className="botao-sobre">
              Conheça nossa história
            </a>
          </div>
        </section>

        {/* HISTÓRIA */}
        <section className="historia-sobre" id="nossa-historia">
          <div className="imagem-historia">
            <img
              src="https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?auto=format&fit=crop&w=1200&q=80"
              alt="Ambiente moderno com móveis planejados"
            />
          </div>

          <div className="texto-historia">
            <span className="subtitulo-sobre">
              QUEM SOMOS
            </span>

            <h2>
              Mais que móveis,
              <span> criamos experiências.</span>
            </h2>

            <p>
              A AR Planejados nasceu com o propósito de transformar
              ambientes por meio de soluções personalizadas,
              valorizando cada espaço e respeitando as necessidades
              de cada cliente.
            </p>

            <p>
              Acreditamos que cada ambiente possui uma identidade
              própria. Por isso, buscamos unir criatividade,
              funcionalidade e atenção aos detalhes em cada projeto.
            </p>

            <a href={WHATSAPP_URL} target="_blank"
              rel="noopener noreferrer" className="botao-sobre">
              Entre em contato
            </a>
          </div>
        </section>

        {/* MISSÃO, VISÃO E VALORES */}
        <section className="valores-sobre">
          <div className="titulo-valores">
            <span className="subtitulo-sobre">
              NOSSA ESSÊNCIA
            </span>

            <h2>O que nos guia</h2>

            <p>
              Nosso compromisso está presente em cada etapa
              do desenvolvimento de um projeto.
            </p>
          </div>

          <div className="grade-valores">
            <article className="card-valor">
              <span className="icone-valor">01</span>
              <h3>Missão</h3>
              <p>
                Desenvolver móveis planejados que proporcionem
                funcionalidade, beleza e satisfação aos clientes.
              </p>
            </article>

            <article className="card-valor">
              <span className="icone-valor">02</span>
              <h3>Visão</h3>
              <p>
                Ser reconhecida pela qualidade, criatividade e
                excelência em soluções para ambientes planejados.
              </p>
            </article>

            <article className="card-valor">
              <span className="icone-valor">03</span>
              <h3>Valores</h3>
              <p>
                Trabalhar com compromisso, respeito, transparência,
                qualidade e atenção a cada detalhe.
              </p>
            </article>
          </div>
        </section>

        {/* DIFERENCIAIS */}
        <section className="diferenciais-sobre">
          <div className="texto-diferenciais">
            <span className="subtitulo-sobre">
              POR QUE ESCOLHER A AR?
            </span>

            <h2>
              Cuidado em cada detalhe,
              qualidade em cada projeto.
            </h2>

            <p>
              Nosso objetivo é entregar ambientes que combinem
              com o estilo de vida de cada cliente.
            </p>

            <div className="lista-diferenciais">
              <div>
                <span>✓</span>
                <p>Projetos personalizados</p>
              </div>

              <div>
                <span>✓</span>
                <p>Otimização inteligente dos espaços</p>
              </div>

              <div>
                <span>✓</span>
                <p>Design moderno e funcional</p>
              </div>

              <div>
                <span>✓</span>
                <p>Atenção aos detalhes</p>
              </div>
            </div>
          </div>

          <div className="imagem-diferenciais">
            <img
              src="https://images.unsplash.com/photo-1600607687920-4e2a09cf159d?auto=format&fit=crop&w=1200&q=80"
              alt="Interior sofisticado com móveis planejados"
            />
          </div>
        </section>

        {/* CHAMADA FINAL */}
        <section className="chamada-sobre">
          <span className="subtitulo-sobre">
            SEU AMBIENTE MERECE O MELHOR
          </span>

          <h2>
            Vamos criar algo especial juntos?
          </h2>

          <p>
            Entre em contato e conte um pouco sobre o ambiente
            que você deseja transformar.
          </p>

          <a
            href={WHATSAPP_URL}
            target="_blank"
            rel="noopener noreferrer"
            className="botao-sobre"
          >
            Fale conosco pelo WhatsApp
          </a>
        </section>
      </main>

      {/* RODAPÉ */}
      <footer className="rodape-sobre">
        <h3>AR <span>PLANEJADOS</span></h3>
        <p>Transformando espaços em ambientes únicos.</p>
        <span>© 2026 AR Planejados. Todos os direitos reservados.</span>
      </footer>
    </div>
  );
}

export default Sobre;
