import "./RentalCard.css";


export default function RentalCard({rental}){


    const approveRental = async () => {
    try {
        const response = await fetch(
            `http://localhost:5015/approve-rental/${rental.rentalId}`,
            {
                method: "PATCH",
            }
            );

            if (!response.ok) throw new Error("Approve failed");

            alert("Rental approved");
            window.location.reload();

        } catch (err) {
            console.error(err);
        }
    };

    const rejectRental = async () => {
        try {
        const response = await fetch(`http://localhost:5015/cancel-rental/${rental.rentalId}`, {
            method: "PATCH",
        });

        if (!response.ok) throw new Error("Reject failed");

        alert("Rental Rejected!");
        window.location.reload();
        } catch (err) {
            console.error(err);
        }
  };

  const markActive = async () => {
    try {
      const response = await fetch(`http://localhost:5015/start-rental/${rental.rentalId}`, {
        method: "PATCH",
      });

      if (!response.ok) throw new Error("Complete failed");

      alert("Rental Marked as Complete!");
      window.location.reload();
    } catch (err) {
      console.error(err);
    }
  };

  const markComplete = async () => {
    try {
      const response = await fetch(`http://localhost:5015/complete-rental/${rental.rentalId}`, {
        method: "PATCH",
      });

      if (!response.ok) throw new Error("Complete failed");

      alert("Rental Marked as Complete!");
      window.location.reload();
    } catch (err) {
      console.error(err);
    }
  };

    return (
            <div className="rental-card">

                <h2 className="rental-title">{rental.title}</h2>

                <p className={`status-badge status-${rental.status.toLowerCase()}`}>
                {rental.status}
                </p>

                <p><strong>Phone:</strong> {rental.renterPhone}</p>
                <p><strong>Rental ID:</strong> {rental.rentalId}</p>

                <p className="date-range">
                {rental.startDate} → {rental.endDate}
                </p>

                <h3 className="price">Rs. {rental.totalPrice}</h3>

                {/* BUTTON CONDITIONS */}
                {rental.status === "Pending" && (
                <div className="btn-group">
                    <button className="btn btn-success" onClick={approveRental}>
                    Approve
                    </button>
                    <button className="btn btn-danger" onClick={rejectRental}>
                    Reject
                    </button>
                </div>
                )}

                {rental.status === "Approved" && (
                <div className="btn-group">
                    <button className="btn btn-primary" onClick={markActive}>Active</button>
                    <button className="btn btn-danger" onClick={rejectRental}>Remove Approve</button>
                </div>
                )}

                {rental.status === "Active" && (
                <div className="btn-group">
                    <button className="btn btn-primary" onClick={markComplete}>
                    Mark as Complete
                    </button>
                </div>
                )}

            </div>
)

}