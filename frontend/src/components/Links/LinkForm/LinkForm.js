import './LinkForm.css'

const LinkForm = ({message, link, textLink}) => {
    return (
        <div className="form-link">
            <span>{message} <a href={link} className="link signup-link">{textLink}</a></span>
        </div>
    )
}

export default LinkForm 