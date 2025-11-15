import React, {useState} from "react";

export default function EquipmentRentalForm() {

    const [name, setName] = useState("");
    const [phone, setPhone] = useState("");
    const [email, setEmail] = useState("");
    const [title, setTitle] = useState("");
    const [dailyPrice, setDailyPrice] = useState("");
    const [description, setDescription] = useState("");
    const [category, setCategory] = useState("");
    const [date, setCreatedDate] = useState("");
    const [isActive, setIsActive] = useState("");
    const [userId, setUserId]=useState("");
    
    const [loadingSubmit, setLoadingSubmit] = useState(false);
    const [message, setMessage] = useState("");

    const [imageFile, setImageFile] = useState(null);

    const handleImageChange = (e) => {
        setImageFile(e.target.files[0]);
    };


    const handleSubmit = async (e) => {
      e.preventDefault();
      setLoadingSubmit(true);
    
      const formData = new FormData(); 

      formData.append("Title", title);
      formData.append("Category", category);
      formData.append("Description", description);
      formData.append("DailyPrice", dailyPrice);
      formData.append("OwnerName", name);
      formData.append("OwnerPhone", phone);
      formData.append("OwnerEmail", email);
      formData.append("CreatedDate","2024-05-06");
      formData.append("IsActive",true);
      formData.append("UserId","2")

      if(imageFile){
        formData.append("image",imageFile);
      }
      try {
        const response = await fetch("http://localhost:5015/create-items", {
          method: "POST",
          body:formData
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

  
        return(
                <div className="container d-flex justify-content-center mt-5">
            <div className="card p-4" style={{ maxWidth: "600px", width: "100%" }}>
                <h4 className="mb-4">Add New Equipment</h4>

                <form onSubmit={handleSubmit}>

                {/* Equipment Title */}
                <div className="mb-3">
                    <label className="form-label">
                    Equipment Title:
                    </label>
                    <input
                    type="text"
                    className="form-control"
                    value={title}
                    placeholder="Enter equipment title"
                    onChange={(e) => setTitle(e.target.value)}
                    required
                    />
                </div>

                {/* Category */}
                <div className="mb-3">
                    <label className="form-label">
                    Category:
                    </label>
                    <select className="form-select" value={category}
                        onChange={(e) => setCategory(e.target.value)}
                        required
                    
                    >
                    <option value="Electronic">Electronic</option>
                    <option value="Tools">Tools</option>
                    <option value="Camping">Camping</option>
                    <option value="Music">Music</option>
                    <option value="Sport">Sport</option>
                    </select>
                </div>

                {/* Description */}
                <div className="mb-3">
                    <label className="form-label">
                    Description:
                    </label>
                    <textarea
                    className="form-control"
                    value={description}
                    rows="3"
                    placeholder="Write a short description"
                    onChange={(e) => setDescription(e.target.value)}
                    ></textarea>
                </div>

                {/* Daily Rental Price */}
                <div className="mb-3">
                    <label className="form-label">
                    Daily Rental Price:
                    </label>
                    <input
                    type="number"
                    className="form-control"
                    value={dailyPrice}
                    onChange={(e) => setDailyPrice(e.target.value)}
                    placeholder="50"
                    />
                </div>

                {/* Owner Name */}
                <div className="mb-3">
                    <label className="form-label">
                    Owner Name:
                    </label>
                    <input
                    type="text"
                    className="form-control"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    placeholder="matheesha malshan"
                    />
                </div>

                {/* Owner Phone */}
                <div className="mb-3">
                    <label className="form-label">
                    Owner Phone:
                    </label>
                    <input
                    type="text"
                    className="form-control"
                    value={phone}
                    onChange={(e) => setPhone(e.target.value)}
                    placeholder="(555) 123-4567"
                    />
                </div>

                {/* Owner Email */}
                <div className="mb-3">
                    <label htmlFor="ownerEmail" className="form-label">
                    Owner Email:
                    </label>
                    <input
                    type="email"
                    className="form-control"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    placeholder="example@email.com"
                    />
                </div>

                {/* Image Upload */}
                {/* Image Upload */}
                <div className="mb-3">
                <label className="form-label">Upload Image:</label>
                <input
                    type="file"
                    className="form-control"
                    accept="image/*"
                    onChange={handleImageChange}
                />
                </div>

                {/* Submit Button */}
                <button type="submit" className="btn btn-primary w-100" disabled={loadingSubmit}>
                {loadingSubmit ? "Submitting..." : "Submit Equipment"}
            </button>

            {message && <p className="mt-3">{message}</p>}

        </form>
      </div>
    </div>
    )
    

}
