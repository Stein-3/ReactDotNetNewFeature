import { Link } from "react-router-dom";

const SideMenu: React.FC = () => {
  return (
    <>
      <div>MVVMBlog</div>
      <ul>
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/Counter">Counter</Link>
        </li>
        <li>
          <Link to="/FetchData">Fetch Data</Link>
        </li>
      </ul>
    </>
  );
};

export default SideMenu;
