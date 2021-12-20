import { BrowserRouter, Route, Routes } from "react-router-dom";
import Counter from "../Counter/Counter.component";
import FetchData from "../FetchData/FetchData.Component";
import Header from "../Header/Header.component";
import Home from "../Home/Home.component";
import SideMenu from "../SideMenu/SideMenu.component";

const Router: React.FC = () => {
  return (
    <>
      <BrowserRouter>
        <SideMenu />
        <Header />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/Counter" element={<Counter />} />
          <Route path="/FetchData" element={<FetchData />} />
          {/* <Route path="/FetchData/:fetchDate" element={<FetchData2 />} /> */}
        </Routes>
      </BrowserRouter>
    </>
  );
};

export default Router;
