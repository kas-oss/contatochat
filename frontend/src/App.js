import './App.css';
import UserContextProvider from './hooks/UserContext';
import RoutesPage from './Routes';


function App() {
  return (
    <UserContextProvider>
      <RoutesPage />
    </UserContextProvider>
  );
}

export default App;
