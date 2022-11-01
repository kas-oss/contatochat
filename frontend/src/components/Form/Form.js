import './Form.css'

const Form = ({ children, onSubmit, headerText }) => {
    return (
        <section className="container forms">
            <div className="form login">
                <div className="form-content">
                    <header>{headerText}</header>
                    <form onSubmit={onSubmit}>
                        {children}
                    </form>
                </div>
            </div>
        </section>
    )
}

export default Form