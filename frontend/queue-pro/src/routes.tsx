import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Main from "./pages/Main";

export default function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<Login />} />
        {<Route path="/" element={<Navigate to="/login" replace />} />}
        {<Route path="/register" element={<Register />} /> }
        {<Route path="/main" element={<Main />} /> }

      </Routes>
    </BrowserRouter>
  );
}