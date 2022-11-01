import './App.css';
import UserContextProvider from './hooks/UserContext';
import Login from './pages/Login/Login'
import Registration from './pages/Registration/Registration';

function App() {
  return (
    <UserContextProvider>
      <Registration />
    </UserContextProvider>
  );
}

export default App;
