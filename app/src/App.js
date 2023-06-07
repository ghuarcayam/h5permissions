import logo from './logo.svg';
import './App.css';
import { Routes, Route } from 'react-router-dom';
import Home from './features/Home'
import NewPermission from './features/NewPermission'
import EditPermission from './features/EditPermission'

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Home/>} />
        <Route path="/new" element={<NewPermission/>} />
        <Route path="/edit/:id" element={<EditPermission/>} />
      </Routes>
    </div>
  );
}

export default App;
