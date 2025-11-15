import { Link } from "react-router-dom"

export default function Header(){
    return(
       
     <header className="d-flex flex-wrap justify-content-center py-3 mb-4 border-bottom">

      <a href="/" className="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-dark text-decoration-none">
        <svg className="bi me-2" width="40" height="32"><use xlinkHref="#bootstrap"></use></svg>
        <span className="fs-4">RentHub</span>
      </a>

      <ul className="nav nav-pills">
        <li className="nav-item"><Link to="/" className="nav-link active" aria-current="page">Home</Link></li>
        <li className="nav-item"><Link to="/equipment" className="nav-link">List Equipment</Link></li>
        <li className="nav-item"><Link to="/myrentals" className="nav-link">My Rentals</Link></li>
    
      </ul>
    </header>
      
    )
}