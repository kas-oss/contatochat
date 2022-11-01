import './LinkForm.css'
import { Link } from "react-router-dom"

const LinkForm = ({ message, link, textLink }) => {
    return (
        <div className="form-link">
            <span>
                {message}
                <Link to={link} className="link signup-link">{textLink}</Link>
            </span>
        </div>
    )
}

export default LinkForm 