import './Form.css'

const Form = ({children, onSubmit}) => {
    return (
        <div className="form login">
            <div className="form-content">
                <header>Login</header>
                <form onSubmit={onSubmit}>
                    {children}
                </form>

            </div>
        </div>
    )
}

export default Form