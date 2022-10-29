import './App.css';
import UserContextProvider from './hooks/UserContext';
import Login from './pages/Login/Login'

function App() {
  return (
    <UserContextProvider>
      <Login />
    </UserContextProvider>
  );
}

export default App;
