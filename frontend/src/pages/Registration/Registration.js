import { useContext, useState } from "react"

import { UserContext } from "../../hooks/UserContext"
import { useNavigate } from "react-router-dom"

import Button from "../../components/Button/Button"
import ErrorForm from "../../components/Errors/ErrorForm/ErrorForm"
import Form from "../../components/Form/Form"
import Input from "../../components/Inputs/Input/Input"
import LinkForm from "../../components/Links/LinkForm/LinkForm"



const Registration = () => {
    const { registration } = useContext(UserContext)
    const [error, setError] = useState('')
    const navigate = useNavigate()

    const onSubmit = async (e) => {
        e.preventDefault()
        
        const name = e.target.name.value.trim()
        const email = e.target.email.value.trim()
        const phone = e.target.phone.value.trim()
        const pass = e.target.pass.value.trim()
        const confirmPass = e.target.confirmPass.value.trim()

        if (name.length <= 0 ||
            email.length <= 0 ||
            phone.length <= 0 ||
            pass.length <= 0 ||
            confirmPass.length <= 0
        ) {
            setError('Todos os campos precisam estar preenchidos.')
        }
        else if (pass !== confirmPass) {
            setError('Senhas não são iguais.')
        }
        else {
            try {
                await registration(name, email, phone, pass, confirmPass);
                navigate('/')
            } catch (error) {
                console.log(error)
            }
        }
    }

    return (
        <Form onSubmit={onSubmit} headerText='Cadastro' action="#">
            <Input type="text" name='name' placeholder="Nome" className="input" />
            <Input type="email" name='email' placeholder="Email" className="input" />
            <Input type="tel" name='phone' placeholder="Telefone" className="input" />
            <Input type="password" name='pass' placeholder="Senha" className="password" />
            <Input type="password" name='confirmPass' placeholder="Senha" className="password" />
            <ErrorForm text={error} />

            <Button text="Cadastrar" />
            <LinkForm message='Já possui uma conta? ' link="/login" textLink="Login" />
        </Form>
    )
}

export default Registration