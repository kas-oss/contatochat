import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'

import Login from './pages/Login/Login'
import Registration from './pages/Registration/Registration';
import Chat from './pages/Chat/Chat';

const RoutesPage = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/cadastro" element={<Registration />} />
                <Route path='/' element={<Chat />} />
                <Route path="*" element={<Navigate replace to="/" />} />
            </Routes>
        </BrowserRouter>
    )
}

export default RoutesPage