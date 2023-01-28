import './Search.css'

const Search = ({filterContact, clearContact}) => {

    const onChange = (e) => filterContact(e.target.value)
    const onClick = (e) => clearContact()

    return (
        <div className="search-chat">
            <div>
                <input onChange={onChange} onClick={onClick} type="search" placeholder="Pesquisar" />
                <ion-icon name="search-outline"></ion-icon>
            </div>
        </div>
    )
}

export default Search