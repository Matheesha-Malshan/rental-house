import React, { useEffect, useState } from "react";
import RentalCard from "../equipment/RentalCard";

export default function MyRental(){

    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(()=>{
        fetch('http://localhost:5015/find-rentals-by-userId/3')
        .then((response)=>{
            if(!response.ok){
                throw new Error("network response error");
            }
            return response.json();
        })
        .then((data)=>{
            setData(data);
            setLoading(false);
        })
        .catch((error)=>{
            setLoading(false);
        });
    },[]);

    console.log(data);

    return (
        <div className="container">
         
                
                {loading ? (
                    <p>Loading...</p>
                    ) : (
                    <div className="row">
                        {data.map((rental, index) => (
                        <div className="col-md-4 mb-3" key={index}>
                            <RentalCard rental={rental} />
                        </div>
                        ))}
                    </div>
                    )}
            
        </div>

    );

}
