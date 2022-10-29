import './Button.css'

const Button = ({text}) => {
    return (
        <div className="field button-field">
            <button>{text}</button>
        </div>
    )
}

export default Button