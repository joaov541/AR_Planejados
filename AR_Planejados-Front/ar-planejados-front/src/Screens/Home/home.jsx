
import { Link } from "react-router-dom";
import Header from "../../Components/Header/header";
import "./Home.css";

const WHATSAPP_URL = "https://wa.me/5511947748822";

function Home() {
    return (
        <div className="pagina-home">

            <Header />

            {/* BANNER PRINCIPAL */}
            <section className="hero">

                <div className="hero-overlay"></div>

                <div className="hero-container">
                    <span className="hero-subtitulo">
                        AR PLANEJADOS
                    </span>

                    <h1>
                        Seu espaço,
                        <br />
                        <span>do seu jeito.</span>
                    </h1>

                    <p>
                        Criamos móveis planejados que transformam
                        ambientes em espaços únicos, funcionais
                        e cheios de personalidade.
                    </p>

                    <div className="hero-botoes">
                        <Link to="/projetos" className="botao-principal">
                            Conheça nossos projetos
                        </Link>

                        <Link to="/orcamento" className="botao-secundario">
                            Solicitar orçamento
                        </Link>
                    </div>
                </div>

            </section>

            {/* APRESENTAÇÃO */}
            <section className="sobre-home">

                <div className="sobre-container">

                    <div className="sobre-texto">
                        <span className="secao-label">
                            SOBRE A AR PLANEJADOS
                        </span>

                        <h2>
                            Mais que móveis,
                            <span> criamos ambientes.</span>
                        </h2>

                        <p>
                            Cada ambiente possui sua própria
                            identidade. Por isso, desenvolvemos
                            projetos planejados que aproveitam
                            cada espaço e valorizam os detalhes.
                        </p>

                        <Link to="/sobre" className="link-detalhes">
                            Conheça nossa história →
                        </Link>
                    </div>

                    <div className="sobre-imagem">
                        <img
                            src="https://images.unsplash.com/photo-1600607687939-ce8a6c25118c"
                            alt="Ambiente moderno com móveis planejados"
                        />
                    </div>

                </div>

            </section>

            {/* PROJETOS */}
            <section className="projetos-home">

                <div className="projetos-titulo">
                    <span className="secao-label">
                        NOSSO TRABALHO
                    </span>

                    <h2>
                        Projetos que inspiram.
                    </h2>

                    <p>
                        Conheça alguns ambientes e possibilidades
                        desenvolvidos pela nossa marcenaria.
                    </p>
                </div>

                <div className="projetos-grid">

                    <article className="projeto-card">
                        <img
                            src="https://images.unsplash.com/photo-1600607687920-4e2a09cf159d"
                            alt="Cozinha planejada"
                        />
                        <div className="projeto-info">
                            <h3>Cozinhas planejadas</h3>
                            <p>Funcionalidade em cada detalhe.</p>
                        </div>
                    </article>

                    <article className="projeto-card">
                        <img
                            src="https://images.unsplash.com/photo-1600210492486-724fe5c67fb0"
                            alt="Sala planejada"
                        />
                        <div className="projeto-info">
                            <h3>Salas planejadas</h3>
                            <p>Conforto e personalidade.</p>
                        </div>
                    </article>

                    <article className="projeto-card">
                        <img
                            src="https://images.unsplash.com/photo-1616486338812-3dadae4b4ace"
                            alt="Quarto planejado"
                        />
                        <div className="projeto-info">
                            <h3>Quartos planejados</h3>
                            <p>Organização e aconchego.</p>
                        </div>
                    </article>

                </div>

                <Link to="/projetos" className="botao-projetos">
                    Ver todos os projetos
                </Link>

            </section>

            {/* DIFERENCIAIS */}
            <section className="diferenciais-home">

                <div className="projetos-titulo">
                    <span className="secao-label">
                        NOSSO DIFERENCIAL
                    </span>

                    <h2>
                        Planejados para você.
                    </h2>
                </div>

                <div className="diferenciais-grid">

                    <article>
                        <span className="diferencial-numero">01</span>
                        <h3>Personalização</h3>
                        <p>
                            Projetos desenvolvidos de acordo
                            com suas necessidades.
                        </p>
                    </article>

                    <article>
                        <span className="diferencial-numero">02</span>
                        <h3>Funcionalidade</h3>
                        <p>
                            Soluções inteligentes para aproveitar
                            melhor cada ambiente.
                        </p>
                    </article>

                    <article>
                        <span className="diferencial-numero">03</span>
                        <h3>Atenção aos detalhes</h3>
                        <p>
                            Cuidado em cada escolha e acabamento
                            do seu projeto.
                        </p>
                    </article>

                </div>

            </section>

            {/* CHAMADA PARA ORÇAMENTO */}
            <section className="orcamento-home">

                <span>VAMOS PLANEJAR SEU ESPAÇO?</span>

                <h2>
                    Seu próximo projeto começa aqui.
                </h2>

                <p>
                    Entre em contato e conte para nós o que
                    você deseja transformar.
                </p>

                <a
                    href={WHATSAPP_URL}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="botao-whatsapp"
                >
                    Fale conosco pelo WhatsApp
                </a>

            </section>

            {/* FOOTER */}
            <footer className="footer-home">
                <div className="footer-container">

                    <div>
                        <h2>AR PLANEJADOS</h2>
                        <p>
                            Projetando ambientes,
                            transformando espaços.
                        </p>
                    </div>

                    <span>
                        © {new Date().getFullYear()} AR Planejados.
                        Todos os direitos reservados.
                    </span>

                </div>
            </footer>

        </div>
    );
}

export default Home;
