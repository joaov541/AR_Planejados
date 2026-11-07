
import { BrowserRouter, Routes, Route } from "react-router-dom";

import Home from "../Screens/Home/home";
import Projetos from "../Screens/Projetos/projetos";
import Sobre from "../Screens/Sobre/sobre";

function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/projetos" element={<Projetos />} />
        <Route path="/sobre" element={<Sobre />} />
      </Routes>
    </BrowserRouter>
  );
}

export default AppRoutes;
