
import { useState } from "react";
import { NavLink } from "react-router-dom";
import "./Header.css";

function Header() {
    const [menuAberto, setMenuAberto] = useState(false);

    function fecharMenu() {
        setMenuAberto(false);
    }

    return (
        <header className="header">
            <div className="header-container">

                <NavLink to="/" className="logo" onClick={fecharMenu}>
                    <span className="logo-ar">AR</span>
                    <span className="logo-texto">PLANEJADOS</span>
                </NavLink>

                <button
                    className="menu-mobile"
                    onClick={() => setMenuAberto(!menuAberto)}
                    aria-label="Abrir ou fechar menu"
                    aria-expanded={menuAberto}
                >
                    <span></span>
                    <span></span>
                    <span></span>
                </button>

                <nav className={`nav ${menuAberto ? "nav-aberto" : ""}`}>
                    <NavLink to="/" end onClick={fecharMenu}>
                        Home
                    </NavLink>

                    <NavLink to="/projetos" onClick={fecharMenu}>
                        Projetos
                    </NavLink>

                    <NavLink to="/sobre" onClick={fecharMenu}>
                        Sobre nós
                    </NavLink>

                    <NavLink
                        to="/orcamento"
                        className="nav-orcamento"
                        onClick={fecharMenu}
                    >
                        Solicitar orçamento
                    </NavLink>
                </nav>

            </div>
        </header>
    );
}

export default Header;
