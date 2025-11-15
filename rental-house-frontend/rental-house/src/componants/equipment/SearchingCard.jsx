import { useState, useEffect } from "react";

export default function SearchingCard({ onSearch ,onSelectCategory}) {

  const [searchText, setSearchText] = useState("");
  const [results, setResults] = useState([]);
  const [showResults, setShowResults] = useState(false);

  const handleSearch = (e) => {
    setSearchText(e.target.value);
    setShowResults(true);
  };

  useEffect(() => {
    if (searchText.trim() === "") {
      setResults([]);
      return;
    }

    const delay = setTimeout(() => {
      fetchData(searchText);
    }, 500);

    return () => clearTimeout(delay);
  }, [searchText]);

  const fetchData = async (query) => {
    try {
      const response = await fetch(
        `http://localhost:5015/get-all-rentals-by-letters/${query}`
      );
      const data = await response.json();
      setResults(data);
    } catch (err) {
      console.error(err);
    }
  };

  const handleSelect = (value) => {
    setSearchText(value);
    setShowResults(false);
  };

  const handleSubmit = () => {
    onSearch(searchText); 
  };

  const handleSelectedData = (value) => {
    onSelectCategory(value);
  };

  return (
              <div style={{ width: "600px", margin: "0 auto" }}> 
          {/* Row: Category + Search + Button */}
          <div style={{ display: "flex", gap: "10px", position: "relative" }}> {/* relative wrapper */}
            
            {/* Category Dropdown */}
            <select
              onChange={(e) => handleSelectedData(e.target.value)}
              style={{
                flex: "1",
                padding: "10px",
                borderRadius: "5px",
                border: "1px solid #ccc",
              }}
            >
              <option value="">Select Category</option>
              <option value="Tools">Tools</option>
              <option value="electronic">Electronic</option>
              <option value="wood">Wood</option>
              <option value="sports">Sports</option>
              <option value="camera">Camera</option>
            </select>

            {/* Input + Dropdown Wrapper */}
            <div style={{ flex: "2", position: "relative" }}> 
              <input
                type="text"
                placeholder="Search rentals..."
                value={searchText}
                onChange={handleSearch}
                onFocus={() => setShowResults(true)}
                style={{
                  width: "100%",
                  padding: "10px",
                  borderRadius: "5px",
                  border: "1px solid #ccc",
                }}
              />

              {/* Dropdown Suggestions */}
              {showResults && results.length > 0 && (
                <ul
                  style={{
                    position: "absolute",
                    top: "42px", // just below the input
                    left: 0,
                    width: "100%",
                    background: "white",
                    border: "1px solid #ddd",
                    borderRadius: "5px",
                    listStyle: "none",
                    padding: 0,
                    margin: 0,
                    zIndex: 10,
                    maxHeight: "200px",
                    overflowY: "auto",
                    boxShadow: "0 4px 6px rgba(0,0,0,0.1)",
                  }}
                >
                  {results.map((item, index) => (
                    <li
                      key={index}
                      onClick={() => handleSelect(item)}
                      style={{ padding: "10px", cursor: "pointer" }}
                    >
                      {item}
                    </li>
                  ))}
                </ul>
              )}
            </div>

            {/* Search Button */}
            <button
              className="btn btn-success"
              onClick={handleSubmit}
              style={{ flex: "0 0 100px" }}
            >
              Search
            </button>
          </div>
        </div>

);

}
