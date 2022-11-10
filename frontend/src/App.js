import UserContextProvider from './hooks/UserContext';
import RoutesPage from './routes';


function App() {
  return (
    <UserContextProvider>
      <RoutesPage />
    </UserContextProvider>
  );
}

export default App;
