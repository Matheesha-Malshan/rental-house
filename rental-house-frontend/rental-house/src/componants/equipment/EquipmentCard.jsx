import "./EquipmentCard.css"; 
import { useNavigate } from "react-router-dom";

export default function EquipmentCard({ rental }) {


  const navigate = useNavigate();

  return (
        <div className="card-container">
      
      {/* ---- IMAGE SECTION ---- */}
      <div className="card-image-wrapper">
        <img
          src={"https://tse4.mm.bing.net/th/id/OIP.PthpoFVlpYshM498ZCYWNQHaEl?cb=ucfimg2ucfimg=1&rs=1&pid=ImgDetMain&o=7&rm=3"}
          alt={rental.title}
          className="card-image"
        />
      </div>

      {/* ---- DETAILS SECTION ---- */}
      <div className="card-details">

        <span className="card-category">
          {rental.category}
        </span>

        <h2 className="card-title">{rental.title}</h2>

        <p className="card-price">${rental.dailyPrice}/day</p>

        <div className="card-owner">
          <p><strong>Owner:</strong> {rental.ownerName}</p>
          <p><strong>Phone:</strong> {rental.ownerPhone}</p>
        </div>

        <div
          className={`card-availability ${
            rental.isActive ? "available" : "not-available"
          }`}
        >
          {rental.isActive ? "Available" : "Not Available"}
        </div>

        <button className="card-button" onClick={() => navigate("/rental", { state: { rental } })}>
          Rent Now
        </button>

      </div>

    </div>
  )
}
