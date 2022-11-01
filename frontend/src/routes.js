import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'

import Login from './pages/Login/Login'
import Registration from './pages/Registration/Registration';

const RoutesPage = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/cadastro" element={<Registration />} />
                <Route path="*" element={<Navigate replace to="/login" />} />
            </Routes>
        </BrowserRouter>
    )
}

export default RoutesPage