import React, { useEffect, useState } from "react";
import EquipmentCard from "../equipment/EquipmentCard";
import SearchingCard from "../equipment/SearchingCard";

export default function Home() {
  const [data, setData] = useState([]);
  const [searchedData, setSearchedData] = useState("");
  const [selectededData, setSelectedData] = useState("");
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("http://localhost:5015/get-all-rentals/")
      .then((res) => res.json())
      .then((data) => {
        setData(data);
        setLoading(false);
      })
      .catch(() => setLoading(false));
  }, []);

  
  useEffect(() => {
    if (searchedData === "") return;

    setLoading(true);

    fetch(`http://localhost:5015/get-all-rentals-by-title/${searchedData}`)
      .then((res) => res.json())
      .then((data) => {
        setData(data);   
        setLoading(false);
      })
      .catch(() => setLoading(false));
  }, [searchedData]);  



    useEffect(() => {
    if (!selectededData) return;
    console.log(selectededData)

    setLoading(true);

    fetch(`http://localhost:5015/get-all-rentals-by-category/${selectededData}`)
      .then((res) => res.json())
      .then((data) => {
        setData(data);   
        setLoading(false);
      })
      .catch(() => setLoading(false));
  }, [selectededData]);  

  return (
    <div className="container">
      
    
        <div
            style={{
                display: "flex",
                justifyContent: "center",
                marginTop: "10px",   // space from top
                marginBottom: "100px" // space from bottom
            }}
            >
            <SearchingCard
                onSearch={setSearchedData}
                onSelectCategory={setSelectedData}
            />
            </div>


      {loading ? (
        <p>Loading...</p>
      ) : (
        <div className="row">
          {data.map((rental, index) => (
            <div className="col-md-4 mb-3" key={index}>
              <EquipmentCard rental={rental} />
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
