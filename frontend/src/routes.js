import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'

import Login from './pages/Login/Login'
import Registration from './pages/Registration/Registration';
import Chat from './pages/Chat/Chat';
import PrivateRoute from './components/PrivateRoute/PrivateRoute';

const RoutesPage = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/cadastro" element={<Registration />} />

                <Route element={<PrivateRoute/>}>
                    <Route path='/' element={<Chat />} />
                </Route>
                
                <Route path="*" element={<Navigate replace to="/" />} />
            </Routes>
        </BrowserRouter>
    )
}

export default RoutesPage