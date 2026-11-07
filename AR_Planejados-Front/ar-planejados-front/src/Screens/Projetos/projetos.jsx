
import { useState } from "react";
import { Link } from "react-router-dom";
import Header from "../../Components/Header/header";
import "./Projetos.css";

const WHATSAPP_URL = "https://wa.me/5511947748822";

const projetos = [
  {
    id: 1,
    nome: "Cozinha Planejada",
    categoria: "Cozinhas",
    descricao: "Um ambiente moderno, funcional e sofisticado.",
    imagem: "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=1000&q=80",
  },
  {
    id: 2,
    nome: "Sala de Estar",
    categoria: "Salas",
    descricao: "Design contemporâneo com aproveitamento de espaço.",
    imagem: "https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?auto=format&fit=crop&w=1000&q=80",
  },
  {
    id: 3,
    nome: "Quarto Planejado",
    categoria: "Quartos",
    descricao: "Conforto e organização em cada detalhe.",
    imagem: "https://images.unsplash.com/photo-1616486338812-3dadae4b4ace?auto=format&fit=crop&w=1000&q=80",
  },
  {
    id: 4,
    nome: "Cozinha Contemporânea",
    categoria: "Cozinhas",
    descricao: "Elegância e praticidade para o dia a dia.",
    imagem: "https://images.unsplash.com/photo-1600607687939-ce8a6c25118c?auto=format&fit=crop&w=1000&q=80",
  },
  {
    id: 5,
    nome: "Ambiente Integrado",
    categoria: "Salas",
    descricao: "Integração de ambientes com personalidade.",
    imagem: "https://images.unsplash.com/photo-1600566753086-00f18fb6b3ea?auto=format&fit=crop&w=1000&q=80",
  },
  {
    id: 6,
    nome: "Quarto Minimalista",
    categoria: "Quartos",
    descricao: "Simplicidade, beleza e funcionalidade.",
    imagem: "https://images.unsplash.com/photo-1615874694520-474822394e73?auto=format&fit=crop&w=1000&q=80",
  },
];

function Projetos() {
  const [categoriaAtiva, setCategoriaAtiva] = useState("Todos");

  const categorias = ["Todos", "Cozinhas", "Salas", "Quartos"];

  const projetosFiltrados =
    categoriaAtiva === "Todos"
      ? projetos
      : projetos.filter(
          (projeto) => projeto.categoria === categoriaAtiva
        );

  return (
    <div className="pagina-projetos">
      <Header />

      <main>
        <section className="banner-projetos">
          <div className="conteudo-banner-projetos">
            <span className="subtitulo-projetos">
              NOSSOS TRABALHOS
            </span>

            <h1>
              Projetos que transformam
              <span> ambientes em experiências.</span>
            </h1>

            <p>
              Conheça alguns dos nossos projetos e descubra como
              podemos transformar seu ambiente com móveis planejados.
            </p>

            <a href="#galeria-projetos" className="botao-projetos">
              Explorar projetos
            </a>
          </div>
        </section>

        <section className="introducao-projetos">
          <span className="linha-decorativa"></span>

          <span className="subtitulo-projetos">
            INSPIRAÇÃO E PERSONALIDADE
          </span>

          <h2>
            Cada detalhe faz a diferença.
          </h2>

          <p>
            Desenvolvemos soluções planejadas que unem beleza,
            qualidade e funcionalidade. Cada projeto é pensado
            para valorizar seu espaço e atender às suas necessidades.
          </p>
        </section>

        <section
          className="galeria-projetos"
          id="galeria-projetos"
        >
          <div className="cabecalho-galeria">
            <div>
              <span className="subtitulo-projetos">
                NOSSO PORTFÓLIO
              </span>

              <h2>Conheça nossos projetos</h2>
            </div>

            <p>
              Ambientes criados para combinar com você.
            </p>
          </div>

          <div className="filtros-projetos">
            {categorias.map((categoria) => (
              <button
                key={categoria}
                className={
                  categoriaAtiva === categoria ? "filtro ativo" : "filtro"
                }
                onClick={() => setCategoriaAtiva(categoria)}
              >
                {categoria}
              </button>
            ))}
          </div>

          <div className="grade-projetos">
            {projetosFiltrados.map((projeto) => (
              <article className="card-projeto" key={projeto.id}>
                <div className="imagem-projeto">
                  <img
                    src={projeto.imagem}
                    alt={projeto.nome}
                    loading="lazy"
                  />

                  <span className="categoria-projeto">
                    {projeto.categoria}
                  </span>
                </div>

                <div className="informacoes-projeto">
                  <h3>{projeto.nome}</h3>
                  <p>{projeto.descricao}</p>
                </div>
              </article>
            ))}
          </div>
        </section>

        <section className="chamada-projetos">
          <div>
            <span className="subtitulo-projetos">
              SEU PROJETO COMEÇA AQUI
            </span>

            <h2>
              Vamos transformar seu ambiente?
            </h2>

            <p>
              Conte para nós o que você imagina. Nossa equipe está
              pronta para conversar e ajudar a tirar sua ideia do papel.
            </p>
          </div>

          <a
            href={WHATSAPP_URL}
            target="_blank"
            rel="noopener noreferrer"
            className="botao-projetos"
          >
            Fale pelo WhatsApp
          </a>
        </section>
      </main>

      <footer className="rodape-projetos">
        <h3>AR <span>PLANEJADOS</span></h3>
        <p>Transformando espaços em ambientes únicos.</p>
        <span>© 2026 AR Planejados. Todos os direitos reservados.</span>
      </footer>
    </div>
  );
}

export default Projetos;
