import {BrowserRouter as Router,Routes,Route} from 'react-router-dom'

import Heros from './componants/layout/Heros';
import 'bootstrap/dist/css/bootstrap.min.css';
import Home from './componants/pages/Home';
import RentalForm from './componants/rental/RentalForm';
import Header from './componants/layout/Header';
import Equipment from './componants/rental/EquipmentForm';
import MyRental from './componants/pages/MyRental';

function App() {
  
  return (
    <Router>
      <Header/>
      <Heros/>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/rental" element={<RentalForm />} />
        <Route path="/equipment" element={<Equipment />} />
        <Route path='/myrentals' element={<MyRental />}/>
      </Routes>
    </Router>
    
  )
}

export default App
