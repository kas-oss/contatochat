import { useState } from 'react'
import './Input.css'

const Input = ({ type, placeholder, className, name }) => {
    const [toggleInput, setToggleInput] = useState({ type, class: "bx-hide" })

    const showPassword = () => {
        if (toggleInput.type === type) {
            setToggleInput({ type: 'text', class: 'bx-show' });
        } else {
            setToggleInput({ type, class: 'bx-hide' });
        }
    }

    return (
        <div className="field input-field">
            <input type={toggleInput.type} name={name} placeholder={placeholder} className={className} />
            {type === 'password' &&
                <i onClick={showPassword} className={`bx ${toggleInput.class} eye-icon`}></i>
            }
        </div>
    )
}

export default Input