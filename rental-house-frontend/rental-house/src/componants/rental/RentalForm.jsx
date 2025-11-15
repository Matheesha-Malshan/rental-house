import { useLocation } from "react-router-dom";
import { useEffect, useState } from "react";


export default function RentalForm(){
    
  const location = useLocation();
  const { rental } = location.state || {};


  const [name, setName] = useState("");
  const [phone, setPhone] = useState("");
  const [email, setEmail] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [totalPrice, setTotalPrice] = useState("");
  const [loadingPrice, setLoadingPrice] = useState(false);
  const [loadingSubmit, setLoadingSubmit] = useState(false);
  const [message, setMessage] = useState("");



  useEffect(()=>{
    const fetchPrice=async ()=>{

      if(!startDate||!endDate||!rental)return;


      setLoadingPrice(true);

      try{
        const response=await fetch("http://localhost:5015/calculate-price-date",{
          method:"POST",
          headers:{"content-Type":"application/json"},
          body:JSON.stringify({
            UserId:rental.userId,
            EquipmentId: rental.id,
            StartDate: startDate,
            EndDate: endDate,
            
          }),
        });

        if(!response.ok) throw new Error("failed to calculate price");
        const data=await response.json();
        setTotalPrice(data.price);
      }
      catch(err){
        setTotalPrice("");
      }
      finally{
        setLoadingPrice(false);
      }
      
    };
    fetchPrice();

  },[startDate,endDate,rental])

    const handleSubmit = async (e) => {
      e.preventDefault();
      setLoadingSubmit(true);

      try {
        const response = await fetch("http://localhost:5015/create-rental", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            EquipmentId: rental.equipmentId,
            RenterName:name,
            RenterPhone:phone,
            RenterEmail:email,
            StartDate: startDate,
            EndDate: endDate,
            TotalPrice:totalPrice,
            Status:"Pending"

          }),
        });

        if (!response.ok) throw new Error("Failed to submit rental");

        setMessage("Rental booked successfully!");
      } catch (err) {
        console.error(err);
        setMessage("Error submitting rental. Please try again.");
      } finally {
        setLoadingSubmit(false);
      }
  };

  console.log("rental id is"+rental.equipmentId);
  console.log("rental id is"+rental.title);


  
  return (
    <div className="container d-flex justify-content-center mt-5">
      <div className="card p-4" style={{ maxWidth: "500px", width: "100%" }}>
        <h4 className="mb-4">Equipment Rental</h4>

        <form onSubmit={handleSubmit}>
          {/* Equipment */}
          <div className="mb-3">
            <label className="form-label">
              Equipment:
            </label>
            <input
              type="text"
              className="form-control"
              value={rental.title}
              readOnly
             
            />
          </div>

          {/* Name */}
          <div className="mb-3">
            <label htmlFor="name" className="form-label">
              Your Name:
            </label>
            <input
              type="text"
              className="form-control"
              value={name}
              onChange={(e) => setName(e.target.value)}
              placeholder="Enter your name"
            />
          </div>

          {/* Phone */}
          <div className="mb-3">
            <label className="form-label">
              Your Phone:
            </label>
            <input
              type="text"
              className="form-control"
              value={phone}
              placeholder="0718852600"
              onChange={(e) => setPhone(e.target.value)}
              required
            />
          </div>

          {/* Email */}
          <input
            type="email"
            className="form-control"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="emalshan@gmail.com"
            required
          />


          {/* Start Date */}
          <div className="mb-3">
              <label className="form-label">Start Date:</label>
              <input
                type="date"
                className="form-control"
                value={startDate}
                onChange={(e) => setStartDate(e.target.value)}
                required
              />
            </div>

          {/* End Date */}
          <div className="mb-3">
            <label className="form-label">End Date:</label>
            <input
              type="date"
              className="form-control"
              value={endDate}
              onChange={(e) => setEndDate(e.target.value)}
              required
            />
        </div>

          {/* Total Price */}
          <div className="mb-3">
          <label className="form-label">Total Price:</label>
          <input
            type="text"
            className="form-control"
            value={loadingPrice ? "Calculating..." : totalPrice || ""}
            readOnly
          />
        </div>

           <button type="submit" className="btn btn-primary w-100" disabled={loadingSubmit}>
            {loadingSubmit ? "Submitting..." : "Submit Rental Request"}
          </button>

          {message && <p className="mt-3">{message}</p>}
        </form>
      </div>
    </div>
  );
}