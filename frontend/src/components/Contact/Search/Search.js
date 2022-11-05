import './Search.css'

const Search = () => {
    return (
        <div className="search-chat">
            <div>
                <input type="text" placeholder="Pesquisar" />
                <ion-icon name="search-outline"></ion-icon>
            </div>
        </div>
    )
}

export default Search